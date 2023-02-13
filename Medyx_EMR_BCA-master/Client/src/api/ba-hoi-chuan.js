import request from "@/utils/request";

export function index(idba, params) {
  return request({
    url: "/benh-an-hoi-chuan",
    method: "get",
    params: {
      idba,
      ...params,
    },
  });
}
export function detail(id) {
  return request({
    url: `/benh-an-hoi-chuan/${id}`,
    method: "get",
  });
}
export function update(idba,stt,data) {
  return request({
    url: `benh-an-hoi-chuan/${idba}/chi-tiet/${stt}`,
    method: "put",
    data
  });
}
export function destroy(id, stt) {
  return request({
    url: `/benh-an-hoi-chuan/${id}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function create(idba, data) {
  return request({
    url: `/benh-an-hoi-chuan/${idba}`,
    method: "post",
    data,
  });
}

export async function print(idba, stt) {
  window.open(
    `${window.origin}/api/benh-an-hoi-chuan/${idba}/print-ba-file/${stt}/Phieuxetnghiem_stt_${stt}.pdf`,
    "_blank"
  );
  return;
}
