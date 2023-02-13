import Vue from "vue";

Vue.filter("date", function(value) {
  if (value) return new Date(value).toLocaleDateString("en-GB");
  else return null;
});
Vue.filter("time", function(value) {
  if (value) return new Date(value).toLocaleTimeString("en-GB");
  else return null;
});
Vue.filter("datetime", function(value) {
  if (value)
    return (
      new Date(value).toLocaleDateString("en-GB") +
      " " +
      new Date(value).toLocaleTimeString("en-GB")
    );
  else return null;
});
Vue.filter("money", function(value) {
  if (value != null)
    return value.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, "$1,");
});
