$(document).ready(function () {

    
    $("#clockIn").click(function () {
        event.preventDefault();

        var date = new Date();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var ampm = hours >= 12 ? 'PM' : 'AM';
        hours = hours % 12;
        hours = hours ? hours : 12; // the hour '0' should be '12'
        minutes = minutes < 10 ? '0'+minutes : minutes;
        document.getElementById("currentTime").innerHTML = hours + ':' + minutes + ' ' + ampm;



    })
    
    $("#clockOut").click(function () {

        var d= new Date();
        var h= d.getHours();
        var m = d.getMinutes();
        var ap = h >= 12 ? 'PM' : 'AM';
        h = h % 12;
        h = h ? h : 12; // the hour '0' should be '12'
        m = m < 10 ? '0'+m : m;
        document.getElementById("currentTime2").innerHTML = h + ':' + m + ' ' + ap;

    });

});



