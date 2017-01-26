(function ($) {
  // worktesttrello.cards.js v1.0.0

  // initialise the popup card screen
  $.fn.card_action = function () {
    $("#send_comment").on("click", function (event) {
      event.preventDefault();
      send_comment();
    });
  }

  // send the comment
  function send_comment() {
    var $divcardcomments = $("#card_comments");
    var $pSubmitStatus = $(".submit-status");
    $pSubmitStatus.removeClass("submit-status-error");
    $pSubmitStatus.html($(this).get_busy_html() + "Sending Comment");
    $pSubmitStatus.show();

    var modelData = new Object();
    modelData.ID = $("#ID").val();
    modelData.Comment = $("#Comment").val();

    $(this).submit(modelData, "Board/AddComment",
      function (value) {
        $pSubmitStatus.hide();
        $("#Comment").val("");
        var $newcomment = $("<div>").css({display: "none"}).load($(this).SiteURLPrefix() + "Board/_LoadCardAction?ID=" + value, function () {
          $(this).prependTo($divcardcomments);
          $(this).slideDown();
        });
      },
      function (error) {
        $pSubmitStatus.html(error);
        $pSubmitStatus.addClass("submit-status-error");
      }
    );
  }
})(jQuery);