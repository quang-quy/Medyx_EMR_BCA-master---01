import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-ttvlt-dot-dieu-tri`,
    method: "get",
    params,
  });
}
export function show(idba , stt) {
  return request({
    url: `/benh-an-ttvlt-dot-dieu-tri/${idba}/chi-tiet/${stt}`,
    method: "get",
  });
}
export function store(data) {
  return request({
    url: `/benh-an-ttvlt-dot-dieu-tri`,
    method: "post",
    data
  });
}
export function update(idba , stt , data) {
  return request({
    url: `/benh-an-ttvlt-dot-dieu-tri/${idba}/chi-tiet/${stt}`,
    method: "put",
    data
  });
}
export function destroy(idba , stt) {
  return request({
    url: `/benh-an-ttvlt-dot-dieu-tri/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function print(idba, stt) {
  window.open(
    `${window.origin}/api/benh-an-ttvlt-dot-dieu-tri/${idba}/print-ba-file/${stt}/DotDieuTriVLTL_idba_${idba}.pdf`,
    "_blank"
  );
  return;
}
