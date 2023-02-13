import Vue from "vue";
import Clipboard from "clipboard";

function clipboardSuccess() {
  Vue.prototype.$snackbar("Đã copy vào bộ nhớ đệm", "success");
}

function clipboardError() {
  Vue.prototype.$snackbar("Copy lỗi", "error");
}

export default function handleClipboard(text, event) {
  const clipboard = new Clipboard(event.target, {
    text: () => text
  });
  clipboard.on("success", () => {
    clipboardSuccess();
    clipboard.destroy();
  });
  clipboard.on("error", () => {
    clipboardError();
    clipboard.destroy();
  });
  clipboard.onClick(event);
}
