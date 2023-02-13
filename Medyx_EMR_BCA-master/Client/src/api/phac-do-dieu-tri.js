import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/benh-an-phac-do-dt",
    method: "get",
    params,
  });
}
export function show(idba, stt) {
  return request({
    url: `/benh-an-phac-do-dt/${idba}/chi-tiet/${stt}`,
    method: "get",
  });
}
export function store(data) {
  return request({
    url: `/benh-an-phac-do-dt`,
    method: "post",
    data,
  });
}
export function update(idba, stt, data) {
  return request({
    url: `/benh-an-phac-do-dt/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `/benh-an-phac-do-dt/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function dsBenhs(params) {
  return request({
    url: "/dm-benh-tat",
    method: "get",
    cache: true,
    params,
  });
}
export function print(idba, stt) {
  window.open(
    `${window.origin}/api/benh-an-phac-do-dt/${idba}/print-ba-file/${stt}/PhacDoDieuTri_idba_${idba}.pdf`,
    "_blank"
  );
  return;
}
