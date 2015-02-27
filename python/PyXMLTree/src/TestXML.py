from xml.dom import minidom

xmldoc = minidom.parse("binary.xml")
#print xmldoc
#xmldoc.toxml()
#grammerNode = xmldoc.firstChild
grammerNode = xmldoc.childNodes[1]
print grammerNode.toxml() 
print grammerNode.childNodes