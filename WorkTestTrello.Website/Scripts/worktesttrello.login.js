(function ($) {
  // worktesttrello.login.js v1.0.0

  // Initialise the login screen
  $.fn.setup_login = function () {
    $("#trello_login").on("click", function (event) {
      event.preventDefault();
      authenticate_trello();
    });

    // Authenticate against trello
    function authenticate_trello() {
      var pLoginStatus = $(".submit-status");
      pLoginStatus.removeClass("submit-status-error");
      pLoginStatus.html($(this).get_busy_html() + "Authenticating against Trello");
      pLoginStatus.show();

      try {
        Trello.authorize({
          name: "Work Test for Trello",
          type: "popup",
          interactive: true,
          expiration: "never",
          persist: true,
          success: function () { authorise_successful(pLoginStatus); },
          error: function () { authorise_error(pLoginStatus) },
          scope: { write: true, read: true },
        });
      } catch (ex) {
        pLoginStatus.html("The following error occurred: <BR />" + ex);
        pLoginStatus.addClass("submit-status-error");
      }
    }

    // Authentication against trello successfull
    function authorise_successful(pLoginStatus) {
      var modelData = new Object();
      modelData.Token = Trello.token();

      $(this).submit(modelData, "Home/Authorise",
        function (value) {
          window.location = $(this).SiteURLPrefix() + "Board"
        },
        function (error) {
          pLoginStatus.html("You were authenticated against Trello but an error occured logging you in. <BR />Please check the Error Log in the DB for more details.")
          pLoginStatus.addClass("submit-status-error");
        }
      );
    }

    // Authentication against trello failed
    function authorise_error(pLoginStatus) {
      pLoginStatus.text("An error occured authenticating against Trello. Please try again.");
      pLoginStatus.addClass("submit-status-error");
    }
  }
})(jQuery);