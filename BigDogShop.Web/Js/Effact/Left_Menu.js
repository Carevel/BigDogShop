$(document).ready(function () {
    //var plus = 'background:url(../Images/Icon/';
    
    $("dt").toggle(function () {
        $("#imgid").remove();
        
        var left = $(this).offset().left;
        var top = $(this).offset().top;
        var img = "<img id='imgid' src='Images/Icons/arrow_state_blue_collapsed.png' style='z-index:10000;'>";
        var css = { postion: "absolute", top: top + "px", left: left + "px", float: "right" };
        $(this).append(img);
        $("#imgid").css(css);
        $(this).siblings().slideToggle("fast");
        $(this).addClass("");
    }, function () {
        $("#imgid").remove();
        var left = $(this).offset().left + 10;
        var top = $(this).offset().top;
        var img = "<img id='imgid' src='Images/Icons/arrow_state_blue_expanded.png' style='z-index:10000;'>";
        var css = { postion: "absolute", top: top + "px", left: left + "px", float:"right" };
        $(this).append(img);
        $("#imgid").css(css);
        $(this).siblings().slideToggle("fast");
       
    });
});