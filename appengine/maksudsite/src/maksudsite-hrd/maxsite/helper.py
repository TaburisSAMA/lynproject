from django.http import Http404, HttpResponse, HttpResponseRedirect
from django.shortcuts import render_to_response
from django.template import Template
from django.template.context import Context
from maxsite.models import get_template_by_model_view, get_content_by_tile,\
    get_content_string_by_tile
import logging

def response_from_db_or_default(module, view, pagename, active_key=None):
    response_dictionary = {"contents": {"pagename": pagename, "module": module, "view": view, "title": ""}}
    appview = get_template_by_model_view(module, view)
    if appview:
        if appview.is_redirect:
            return HttpResponseRedirect(appview.url)
        
        response_dictionary["contents"]["pagename"] = appview.pagename
        response_dictionary["contents"]["title"] = appview.caption
        active_key = view if active_key else active_key 
        response_dictionary["contents"]["h_%s" % active_key] = "active"  
        
        if hasattr(appview, 'default_content') and appview.default_content:
            logging.info("@@@@@ Using Default Content")
            content = appview.default_content.content
        else:
            logging.info("@@@@@ Searching AppContents")
            content = get_content_string_by_tile(module + "-" + view)
        response_dictionary["contents"]["content"] = content
        
        if hasattr(appview, 'template') and appview.template:
            logging.info("@@@@@ Template Found")
            return response_from_string(appview.template.content, response_dictionary)
        else:
            logging.info("@@@@@ Template NOT Found")          
            return render_to_response('layout/default.html', response_dictionary)
    else:
        raise Http404("Page Not Available")
#        logging.info("@@@@@ AppView NOT Found")
#        content = get_content_by_tile(module + "-" + view)
#        if content:
#            response_dictionary["contents"]["content"] = content.content
#            response_dictionary["contents"]["pagename"] = content.caption
#            response_dictionary["contents"]["title"] = content.caption
#            return render_to_response('layout/default.html', response_dictionary)
#        else:
#        raise Http404("Content Not Found")
#        return HttpResponse(status=404)

try:
    from django.views.decorators.csrf import csrf_exempt
except ImportError:
    def csrf_exempt(func):
        return func

def render_from_string(template, dictionary=None, context_instance=None):
    t = Template(template)

    if context_instance:
        context_instance.update(dictionary)
    else:
        context_instance = Context(dictionary)
    return t.render(context_instance)

def response_from_string(*template, **kwargs):
    httpresponse_kwargs = {'mimetype': kwargs.pop('mimetype', None)}
    return HttpResponse(render_from_string(*template, **kwargs), **httpresponse_kwargs)