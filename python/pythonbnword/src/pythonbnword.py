#!/usr/bin/env python
import time
import pygtk
pygtk.require("2.0")
import gtk
import gtk.glade
import sys
import anydbm
import bntranslit
import pango
import os
import codecs

from gtk.gdk import keyval_name     #Get the key pressed
from gtk.gdk import CONTROL_MASK, SHIFT_MASK, MODIFIER_MASK, RELEASE_MASK

editkeys = ["Insert","Home","Page_Up","Page_Down","End","Delete",
            "Left","Right","Up","Down",
            "space","Tab","Excape","Return","KP_Enter"]
shiftkeys = ["Shift_R","Shift_L","Control_R","Control_L","Alt_R",]

dicdigit = {
            "0" : u'\u09E6',
            "1" : u'\u09E7',
            "2" : u'\u09E8',
            "3" : u'\u09E9',
            "4" : u'\u09EA',
            "5" : u'\u09EB',
            "6" : u'\u09EC',
            "7" : u'\u09ED',
            "8" : u'\u09EE',
            "9" : u'\u09EF'
            }
dicnumerickeypad = {   65453 : 45, #-
                        65454 : 46, #.
                        65451 : 43, #+
                        65455 : 47, #/
                        65450 : 42, #*
                        }


font_desc = pango.FontDescription()

glade_file ='bnwordgui.glade'
FILE_EXT = "txt"


class PythonBnWord:
    def __init__(self):
        self.wTree = gtk.glade.XML(glade_file, 'bnWord')
        dic={ 'on_bnWord_destroy' : self.quit,
              'on_entryEn_activate' : self.addtext,
              'on_entryEn_changed' : self.textchanged,
              'on_textviewBn_key_press_event' : self.bntextview_keypress,
              'on_cut1_activate' : self.cuttext,
              'on_copy1_activate' : self.copytext,
              'on_paste1_activate' : self.pastetext,
              'on_select_all1_activate' : self.selectall,
              'on_langBn_activate' : self.toggleBn,
              'on_toggleLang_toggles' : self.toggleBn,
              'on_toolDB_clicked' : self.manageDB,
              'on_open1_activate' : self.openfile,
              'on_save1_activate' : self.savefile,
              'on_save_as1_activate' : self.savefileas,
              'on_quit1_activate' : self.quit,
              'on_toolRepDigit_clicked' : self.replaceDigits
            }
        self.wTree.signal_autoconnect (dic)
        #setup the text view to act as a log window
        self.textviewBn=self.wTree.get_widget('textviewBn')
        self.textBnBuff=gtk.TextBuffer(None)
        self.textviewBn.set_buffer(self.textBnBuff)
        self.bnWord=self.wTree.get_widget('bnWord')
        self.entryEn=self.wTree.get_widget('entryEn')
        self.labelBn=self.wTree.get_widget('labelBn')
        self.toggleLang=self.wTree.get_widget('toggleLang')
        self.menuLangBn=self.wTree.get_widget('langBn')
        self.lang = "en"
        self.project_file = ""
        
        bntranslit.initBnTranslit()
        self.clipboard = gtk.clipboard_get(gtk.gdk.SELECTION_CLIPBOARD)
        #self.clipboard.request_text(self.clipboard_text_received)
        #font_name = "Bitstream Vera Sans"
        font_name = "Vrinda"
        font_desc.set_family(font_name)
        font_size = 16
        font_desc.set_size(int(font_size) * 1024)
        
        self.labelBn.modify_font(font_desc)
        self.textviewBn.modify_font(font_desc)

        
        #self.dbWord = WordDatabase()
        
        return
    #Handlers for the GUI signals
    def quit(self, obj, data=None):
        """Handles the 'destroy' signal of the window."""
        gtk.main_quit()
        sys.exit(1)
        
    def toggleBn(self, obj, data=None):
        if self.lang=="en":
            self.lang="bn"
            self.toggleLang.set_active(True)
            self.menuLangBn.select()
        else:
            self.flushBnText()
            self.toggleLang.set_active(False)
            self.menuLangBn.deselect()
            self.lang="en"

    def copytext(self, obj, data=None):
        self.textBnBuff.copy_clipboard(self.clipboard)
    def cuttext(self, obj, data=None):
        self.textBnBuff.cut_clipboard(self.clipboard, True)
    def pastetext(self, obj, data=None):
        self.textBnBuff.paste_clipboard(self.clipboard, None, True)
    def selectall(self, obj, data=None):
        start, end = self.textBnBuff.get_bounds()
        self.textBnBuff.select_range(start,end)
        pass
    
    def get_selection_iters(self):
        start = None
        end = None
        
        if (not self.textBnBuff):
            self.show_error_dlg("Text buffer not available")
            return start,end
        
        bounds = self.textBnBuff.get_selection_bounds();
        if (bounds):
            start,end = bounds
        else:
            cursor_mark = self.textBnBuff.get_insert()
            start = self.textBnBuff.get_iter_at_mark(cursor_mark)
            end = self.textBnBuff.get_iter_at_mark(cursor_mark)
        return start, end
        
    def insert_text(self, text, start, end):
        #start, end = self.get_selection_iters();
        if ((not start)or(not end)):
            self.show_error_dlg("Error inserting text")
            return;
        self.textBnBuff.delete(start,end)
        
        start_mark = self.textBnBuff.create_mark(None, start, True)
        self.textBnBuff.insert(end,text)
        start = self.textBnBuff.get_iter_at_mark(start_mark)
        self.textBnBuff.select_range(end,start)
        self.textBnBuff.delete_mark(start_mark)
    
    def addtext(self, obj, data=None):
        """Handles the 'clicked' signal of the button."""
        curIter = self.textBnBuff.get_iter_at_mark(self.textBnBuff.get_insert())
        text = self.entryEn.get_text()
        self.textBnBuff.insert(curIter, bntranslit.convertString(text))
        self.entryEn.set_text("")
        bntranslit.reset()
    
    def textchanged(self, obj, data=None):
        text = self.entryEn.get_text()
        self.labelBn.set_text(bntranslit.convertString(text))
        bntranslit.reset()
    
    def flushBnText(self):
        curIter = self.textBnBuff.get_iter_at_mark(self.textBnBuff.get_insert())
        self.textBnBuff.insert(curIter, bntranslit.reset())
        self.labelBn.set_text("")
    
    def bntextview_keypress(self, obj, event, data=None):
        if self.lang=="en":
            return False
        key = keyval_name(event.keyval)
        if key in editkeys:
            self.flushBnText()
            return False
        elif key =="BackSpace":
            strBn  = bntranslit.fin + bntranslit.unfin
            if len(strBn)>0:
                strBn = strBn[0:-1]
                bntranslit.convertString(strBn)
                self.labelBn.set_text(bntranslit.tstr + bntranslit.fin_s + bntranslit.unfin_s)
                return True
            else:
                return False
        elif (event.keyval>=0 and event.keyval<128) or (event.keyval>=65456 and event.keyval<=65465):
            if event.keyval>=65456:
                event.keyval = ord('0')+event.keyval-65456
            bntranslit.translit(chr(event.keyval))
            self.labelBn.set_text(bntranslit.tstr + bntranslit.fin_s + bntranslit.unfin_s)
            return True
        elif event.keyval in dicnumerickeypad.keys():
            event.keyval = dicnumerickeypad[event.keyval]
            bntranslit.translit(chr(event.keyval))
            self.labelBn.set_text(bntranslit.tstr + bntranslit.fin_s + bntranslit.unfin_s)
            return True
        else:
            #self.flushBnText()
            return False
    def manageDB(self, obj, data=None):
        worddb = WordDatabase()
        worddb.run()
        bntranslit.initBnTranslit()
        pass
    def replaceDigits(self, obj, data=None):
        start, end = self.get_selection_iters()
        if start!=None:
            text = self.textBnBuff.get_text(start,end)
            for a in dicdigit.keys():
                text = text.replace(a,dicdigit[a])
            self.insert_text(text, start, end)
    def openfile(self, obj, data=None):
        open_file = self.file_browse(gtk.FILE_CHOOSER_ACTION_OPEN, "")
        if (open_file != ""):
            # We have a path, ensure the proper extension
            open_file, extension = os.path.splitext(open_file)
            open_file = open_file + "." + FILE_EXT
            filein = codecs.open(open_file, "r", "utf-8")
            text = filein.read() 
            self.textBnBuff.set_text(text)
            filein.close()
            self.project_file=open_file
            self.bnWord.set_title("Bangla Word Processor: [" + self.project_file+"]")
    def savefile(self, obj, data=None):
        save_file = self.file_browse(gtk.FILE_CHOOSER_ACTION_SAVE, self.project_file)
        self.saveTextFile(save_file)

    def savefileas(self, obj, data=None):
        save_file = self.file_browse(gtk.FILE_CHOOSER_ACTION_SAVE, "")
        self.saveTextFile(save_file)

    def saveTextFile(self, save_file):
        if (save_file != ""):
            save_file, extension = os.path.splitext(save_file)
            save_file = save_file + "." + FILE_EXT
            fileout = codecs.open(save_file, "w", "utf-8")
            start, end = self.textBnBuff.get_bounds()
            text = self.textBnBuff.get_text(start, end)
            fileout.write(text)
            fileout.close()
            self.project_file=save_file
            self.bnWord.set_title("Bangla Word Processor: [" + self.project_file+"]")

    def file_browse(self, dialog_action, file_name=""):
        """This function is used to browse for a pyWine file.
        It can be either a save or open dialog depending on
        what dialog_action is.
        The path to the file will be returned if the user
        selects one, however a blank string will be returned
        if they cancel or do not select one.
        dialog_action - The open or save mode for the dialog either
        gtk.FILE_CHOOSER_ACTION_OPEN, gtk.FILE_CHOOSER_ACTION_SAVE
        file_name - Default name when doing a save"""

        if (dialog_action==gtk.FILE_CHOOSER_ACTION_OPEN):
            dialog_buttons = (gtk.STOCK_CANCEL
                                , gtk.RESPONSE_CANCEL
                                , gtk.STOCK_OPEN
                                , gtk.RESPONSE_OK)
        else:
            dialog_buttons = (gtk.STOCK_CANCEL
                                , gtk.RESPONSE_CANCEL
                                , gtk.STOCK_SAVE
                                , gtk.RESPONSE_OK)

        file_dialog = gtk.FileChooserDialog(title="Select File"
                        , action=dialog_action
                        , buttons=dialog_buttons)
        """set the filename if we are saving"""
        if (dialog_action==gtk.FILE_CHOOSER_ACTION_SAVE):
            file_dialog.set_current_name(file_name)
        """Create and add the pywine filter"""
        filter = gtk.FileFilter()
        filter.set_name("Text")
        filter.add_pattern("*." + FILE_EXT)
        file_dialog.add_filter(filter)
        """Create and add the 'all files' filter"""
        filter = gtk.FileFilter()
        filter.set_name("All files")
        filter.add_pattern("*")
        file_dialog.add_filter(filter)

        """Init the return value"""
        result = ""
        if file_dialog.run() == gtk.RESPONSE_OK:
            result = file_dialog.get_filename()
        file_dialog.destroy()

        return result
    def show_error_dlg(self, error_string):
        error_dlg = gtk.MessageDialog(type=gtk.MESSAGE_ERROR,
                                        message_format=error_string,
                                        buttons=gtk.BUTTONS_OK)
        error_dlg.run()
        error_dlg.destroy()

class WordDatabase:
    """This class is used to show wineDlg"""
    def __init__(self):
        pass

    def run(self):
        self.wTree = gtk.glade.XML(glade_file, "dbWord")
        dic={ 'on_entryEn_activate' : self.addRecord,
              'on_entryEn_changed' : self.textchanged,
              'on_buttonAdd_clicked' : self.addRecord,
              'on_buttonDelete_clicked' : self.deleteRecord,
              'on_buttonUpdate_clicked' : self.updateRecord,
              'on_entryRaw_activate' : self.setfocustoEn,
              'on_listWord_cursor_changed' : self.cursorchanged
            }
        self.wTree.signal_autoconnect (dic)
        
        self.dlg = self.wTree.get_widget("dbWord")
        self.entryRaw=self.wTree.get_widget('entryRaw')
        self.entryEn=self.wTree.get_widget('entryEn')
        self.labelBn=self.wTree.get_widget('entryBn')
        self.sBn = "Bangla Replacement"
        self.sEn = "English"
        self.listWord = self.wTree.get_widget("listWord")
        self.AddListColumn(self.sEn, 0)
        self.AddListColumn(self.sBn, 1)
        
        self.dbWordList = gtk.ListStore(str, str)
        self.listWord.set_model(self.dbWordList)
        
        self.fillupList()
        
        self.result = self.dlg.run()
        #we are done with the dialog, destroy it
        self.dlg.destroy()
        self.db.close()
        self.dbmain.close()
    def AddListColumn(self, title, columnId):
        column = gtk.TreeViewColumn(title, gtk.CellRendererText(), text=columnId)
        column.set_resizable(True)		
        column.set_sort_column_id(columnId)
        self.listWord.append_column(column)
    def fillupList(self):
        self.db = anydbm.open('bnworddb', 'w')
        self.dbmain = anydbm.open('bntranslit', 'w')

        for d in self.db.keys():
            alist = [d, self.db[d]]
            self.dbWordList.append(alist)
        #self.db.close()
    def addRecord(self, obj, data=None):
        texten = self.entryRaw.get_text()
        textbn = self.labelBn.get_text()
        if texten ==None or texten == "":
            return

        rec = self.db.get(texten, None)
        rec_main = self.dbmain.get(texten, None)
        if rec==None and rec_main==None:
            #maintain both db
            self.db[texten] = textbn
            self.dbmain[texten] = textbn
            alist = [texten,textbn]
            self.dbWordList.append(alist)
            self.entryEn.set_text("")
            self.entryRaw.set_text("")
            self.entryRaw.grab_focus()
        else:   #present in both database
            aiter = self.dbWordList.get_iter_root()
            while aiter!=None:
                if self.dbWordList.get_value(aiter, 0)==texten:
                    self.dbWordList.remove(aiter)
                    self.dbWordList.append([texten,textbn])
                    self.db[texten] = textbn
                    self.dbmain[texten] = textbn
                    self.entryEn.set_text("")
                    self.entryRaw.set_text("")
                    self.entryRaw.grab_focus()
                    return
                else:
                    aiter = self.dbWordList.iter_next(aiter)

    def deleteRecord(self, obj, data=None):
        texten = self.entryRaw.get_text()
        if texten ==None or texten == "":
            return
        rec = self.db.get(texten, None)
        if rec!=None:
            aiter = self.dbWordList.get_iter_root()
            while aiter!=None:
                if self.dbWordList.get_value(aiter, 0)==texten:
                    self.dbWordList.remove(aiter)
                    del self.db[texten]
                    del self.dbmain[texten]
                    return
                else:
                    aiter = self.dbWordList.iter_next(aiter)

    def updateRecord(self, obj, data=None):
        texten = self.entryRaw.get_text()
        textbn = self.labelBn.get_text()
        if texten ==None or texten == "":
            return
        rec = self.db.get(texten, None)
        if rec!=None:
            aiter = self.dbWordList.get_iter_root()
            while aiter!=None:
                if self.dbWordList.get_value(aiter, 0)==texten:
                    self.dbWordList.remove(aiter)
                    self.dbWordList.append([texten,textbn])
                    self.db[texten] = textbn
                    self.dbmain[texten] = textbn
                    return
                else:
                    aiter = self.dbWordList.iter_next(aiter)
    def setfocustoEn(self, obj, data=None):
        texten = self.entryRaw.get_text()
        rec = self.db.get(texten, None)
        if rec!=None:
            self.entryEn.set_text(self.db[texten])
        self.entryEn.grab_focus()
    def textchanged(self, obj, data=None):
        text = self.entryEn.get_text()
        self.labelBn.set_text(bntranslit.convertString(text))
        bntranslit.reset()
    def cursorchanged(self, obi, data=None):
        model, aiter = self.listWord.get_selection().get_selected()
        self.entryRaw.set_text(self.dbWordList.get_value(aiter, 0))
        self.entryEn.set_text(self.dbWordList.get_value(aiter, 1))






if __name__ == '__main__':
   
    PythonBnWord()
    try:
        gtk.threads_init()
    except:
        print 'No threading was enabled when you compiled pyGTK!'
        sys.exit(1)
    gtk.threads_enter()
    gtk.main()
    gtk.threads_leave()
    
    
