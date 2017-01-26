(function ($) {
  // worktesttrello.boards.js v1.0.0

  // Initialise the board screen
  $.fn.setup_boarditem = function () {
    $(window).on("resize", function (event) {
      boarditem_resize();
    });
    boarditem_resize();

    var delay = 0;
    $(".trello-list-tile").each(function () {
      $(this).delay(delay).slideDown(400);
      delay += 100;
    });

    $(".trello-card-tile").on("click", function (event) {
      event.preventDefault();
      var cardid = $(this).data("cardid");
      $(this).open_popup("view_card_popup", true, function (that) {
        return "Board/PopupCardItem?ID=" + cardid;
      }, 700, get_popupcard_height(), getbodyheader_height() + 10);
    });
  }

  // Resize the components on the screen
  function boarditem_resize() {
    var bodyheight = getbody_height();
    var boardheaderheight = getbodyheader_height();

    $(".trello-boarditem-background").height(bodyheight);
    $(".trello-list-container").height(bodyheight - boardheaderheight - 10);
    $(".popup-container").height(get_popupcard_height());
  }

  function getbody_height() {
    return $(window).height() - $(".navbar").height();
  }

  function getbodyheader_height() {
    return $(".trello-boarditem-header").height();
  }

  function get_popupcard_height() {
    return getbody_height() - getbodyheader_height() + 10;
  }
})(jQuery);