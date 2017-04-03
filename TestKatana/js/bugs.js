var bugsManager = (function ($) {

    function getBugs() {
        let promise = new Promise(function(resolve, reject) {
            $.getJSON('/api/bugs', function(data) {
                resolve(data);
            }).fail(function() {
                console.log("error");
                reject("error fetching api");
            });
        });

        return promise;
    }

    function build(idname) {
        var eldiv = $("#"+idname);
        getBugs().then(function(bugs){
            for (var i=0; i<bugs.length;i++) {
                var bug = bugs[i];
                var elspan = "<li>" + bug.State + "</li>";
                eldiv.append(elspan);
            }
        });
    }

    function signal(stat) {
        var statusDiv = $("#" + stat);
        $.connection.hub.logging = true;
        var bugsHub = $.connection.bugs;
        bugsHub.client.sayHello = function (data) {
            var msg = "hello from " + data;
            append(statusDiv, msg);
        };
        $.connection.hub.start().done(function() {
            append(statusDiv, 'hub connection open');
        });

        $("#getone").on('click', function() {
            getOne();
        })
    }


    function append(el, newval) {
        var current = el.text();
        current += "\r\n" + newval;
        el.text(current);
    }

    function getOne() {
        let promise = new Promise(function(resolve, reject) {
            $.getJSON('/api/bugs/1', function(data) {
                resolve(data);
            }).fail(function() {
                console.log("error");
                reject("error fetching api");
            });
        });
        return promise;
    }

    return {
        build: build,
        get: getOne,
        append: append,
        signal: signal
    };

})(jQuery);