$(function () {
    var $el, leftPos, newWidth;
    $mainNav2 = $("#example-two");

    $mainNav2.append("<li id='magic-line-two'></li>");

    var $magicLineTwo = $("#magic-line-two");

    $magicLineTwo
        .width($(".current_page_item_two").width())
        .height(30)
        .css("left", $(".current_page_item_two a").position().left)
        .data("origLeft", $(".current_page_item_two a").position().left)
        .data("origWidth", $magicLineTwo.width());

    $("#example-two a").hover(function () {
        $el = $(this);
        leftPos = $el.position().left;
        newWidth = $el.parent().width();
        $magicLineTwo.stop().animate({
            left: leftPos,
            width: newWidth,
            backgroundColor: $el.attr("rel")
        })
    }, function () {
        $magicLineTwo.stop().animate({
            left: $magicLineTwo.data("origLeft"),
            width: $magicLineTwo.data("origWidth"),
            backgroundColor: $magicLineTwo.data("origColor")
        });
    });

    /* Kick IE into gear */
    $(".current_page_item_two a").mouseenter();
});