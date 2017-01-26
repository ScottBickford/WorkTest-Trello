(function ($) {
  // worktesttrello.core.js v1.0.0

  $.ajaxSetup({ cache: false });  // don't caches ajax calls unless otherwise specified ....

  var msSiteURLPrefix = null;
  var $busy_template = $("#busy_image");

  // Get the Site URL Prefix
  $.fn.SiteURLPrefix = function () {
    if (msSiteURLPrefix == null) {
      msSiteURLPrefix = GetSiteURLPrefix();
    }
    return msSiteURLPrefix;
  }

  // Submit information to the server via ajax
  $.fn.submit = function (modelData, url, success, error) {
    $.ajax({
      url: $(this).SiteURLPrefix() + url,
      dataType: 'json', contentType: "application/json; charset=utf-8", type: "POST",
      data: JSON.stringify(modelData),
      success: function (data) {
        if (data.ErrorOccurred) {
          error(data.ErrorDescription);
        } else {
          success(data.Value);
        }
      },
      error: function (XMLHttpRequest, textStatus, errorThrown) {
        error("The following error occured: <BR />" + errorThrown);
      }
    });
  }

  // Open a popup window
  $.fn.open_popup = function (popupName, ismodal, getURL, width, height, top, onOpen, onClose) {
    if (width == null) { width = 800; }
    if (height == null) { height = 500; }

    // If we haven't created a popup div for this yet, then create one
    if ($("#" + popupName).attr("id") == null) {
      // Create from the xml template
      var $popuptemplate = $("<div>").html($("#popup_container_template").html()).appendTo("body");
      var $container = $popuptemplate.find(".popup-container");
      $container.attr("id", popupName);
      $container.css({ height: height, width: width });
      var $contentcontainer = $popuptemplate.find(".popup-content-container");
      $contentcontainer.attr("id", popupName + "_popupcontainer");
    }
    var that = $(this);

    $("#" + popupName).css({ height: height });
    $("#" + popupName + "_popupcontainer").html($("#popup_loading").html()).show();
    $("#" + popupName).bPopup({
      easing: 'easeInOutBack', //uses jQuery easing plugin
      speed: 450,
      transition: 'slideIn',
      transitionClose: 'slideBack',
      closeClass: 'popup-close',
      position: ['auto', top],
      modalClose: !ismodal,
      onOpen: function () {
        window.setTimeout(function () {
          $("#" + popupName + "_popupcontainer").load($(this).SiteURLPrefix() + getURL(that), function () {
            if (onOpen != null) { onOpen(); }
          });
        }, 450)
      },
      onClose: function () {
        if (onClose != null) {
          onClose();
        }
        $("#" + popupName + "_popupcontainer").html("");  // Remove any html
      }
    });
  }

  $.fn.get_busy_html = function () {
    return $busy_template.html();
  }
})(jQuery);