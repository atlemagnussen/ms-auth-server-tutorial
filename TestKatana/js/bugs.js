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

    return {
        get: build
    };

})(jQuery);