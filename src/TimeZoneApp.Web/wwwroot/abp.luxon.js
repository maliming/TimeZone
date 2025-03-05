var abp = abp || {};
(function () {

    if (!luxon) {
        throw "abp/luxon library requires the luxon library included to the page!";
    }

    /* TIMING *************************************************/

    abp.timing = abp.timing || {};

   // Normalize Date object or date string to standard string format that will be sent to server
   abp.clock.normalizeToString = function (date) {
       if (!date) {
           return date;
       }

       var dateObj = date instanceof Date ? date : new Date(date);
       if (isNaN(dateObj)) {
           return date;
       }

       var timeZone = abp.clock.timeZone();
       if (abp.clock.supportsMultipleTimezone() && timeZone) {
           return luxon.DateTime.fromObject({
               year: dateObj.getFullYear(),
               month: dateObj.getMonth() + 1,
               day: dateObj.getDate(),
               hour: dateObj.getHours(),
               minute: dateObj.getMinutes(),
               second: dateObj.getSeconds()
           }, { zone: timeZone }).setZone("utc").toISO();
       } else {
           return luxon.DateTime.fromJSDate(dateObj).toFormat("yyyy-MM-dd'T'HH:mm:ss");
       }
   };

    // Normalize date string to locale date string that will be displayed to user
    abp.clock.normalizeToLocaleString = function (dateString, options) {
        if (!dateString) {
            return dateString;
        }

        var date = new Date(dateString);
        if (isNaN(date)) {
            return dateString;
        }

        options = options || abp.clock.toLocaleStringOptions;
        if (abp.clock.supportsMultipleTimezone()) {
            var timezone = abp.clock.timeZone();
            if (timezone) {
                return luxon.DateTime.fromJSDate(date)
                    .setZone(timezone)
                    .setLocale(abp.localization.currentCulture.cultureName)
                    .toLocaleString(options);
            }
        }

        return luxon.DateTime.fromJSDate(date)
            .setLocale(abp.localization.currentCulture.cultureName)
            .toLocaleString(options);
    }
})(jQuery);
