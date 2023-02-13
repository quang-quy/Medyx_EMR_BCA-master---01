import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-tai-bien-pttt`,
    method: "get",
    params,
  });
}
export function show(idba, stt) {
  return request({
    url: `/benh-an-tai-bien-pttt/${idba}/chi-tiet/${stt}`,
    method: "get",
  });
}
export function update(idba, stt, data) {
  return request({
    url: `/benh-an-tai-bien-pttt/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function store(data) {
  return request({
    url: `/benh-an-tai-bien-pttt`,
    method: "post",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `/benh-an-tai-bien-pttt/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function print(idba, stt) {
  window.open(
    `${window.origin}/api/benh-an-tai-bien-pttt/${idba}/print-ba-file/${stt}/ThongTinTaiBienPTT_idba_${idba}.pdf`,
    "_blank"
  );
  return;
}

