import request from "@/utils/request";

export function index(idba, params) {
  return request({
    url: "/benh-an-kham-sang-loc-dd",
    method: "get",
    params: {
      idba,
      huy: false,
      ...params,
    },
  });
}
export function indexAdmin(idba, params) {
  return request({
    url: "/benh-an-kham-sang-loc-dd",
    method: "get",
    params: {
      idba,
      ...params,
    },
  });
}
export function dsKhoaDieuTri(params) {
  return request({
    url: "/benh-an-khoa-dieu-tri",
    method: "get",
    params,
  });
}
export function detail(id) {
  return request({
    url: `/benh-an-kham-sang-loc-dd/${id}`,
    method: "get",
  });
}
export function store(data) {
  return request({
    url: `/benh-an-kham-sang-loc-dd`,
    method: "post",
    data,
  });
}
export function update(idba, stt, sttkhoa, data) {
  return request({
    url: `/benh-an-kham-sang-loc-dd/${idba}/chi-tiet/${stt}/${sttkhoa}`,
    method: "put",
    data,
  });
}
export function destroy(idba, stt, sttkhoa) {
  return request({
    url: `/benh-an-kham-sang-loc-dd/${idba}/chi-tiet/${stt}/${sttkhoa}`,
    method: "delete",
  });
}
export async function print(idba, stt, sttkhoa, maBa) {
  window.open(
    `/api/benh-an-kham-sang-loc-dd/${idba}/print-ba-file/${stt}/${sttkhoa}/PhieuDinhDuong-${stt}.pdf`,
    "_blank"
  );
  return;
}
