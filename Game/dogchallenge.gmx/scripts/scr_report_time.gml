///scr_report_time()

var POST_string = "time=" + string(global.reporttime) + "&name=" + string_replace_all(global.name, " ", "+");
show_debug_message(POST_string);
return http_post_string("http://inversedog.ddns.net:9009/", POST_string);
