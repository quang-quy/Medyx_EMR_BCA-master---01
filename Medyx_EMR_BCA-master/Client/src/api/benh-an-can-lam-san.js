import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/benh-an-cls",
    method: "get",
    params,
  });
}
export function detailBaCls(id, stt) {
  return request({
    url: `/benh-an-cls/${id}/chi-tiet/${stt}`,
    method: "get",
  });
}

export function add(data) {
  return request({
    url: `/benh-an-cls`,
    method: "post",
    data
  });
}

export function update(id, stt, data) {
  return request({
    url: `/benh-an-cls/${id}/chi-tiet/${stt}`,
    method: "put",
    data
  });
}
export function destroy(id, stt) {
  return request({
    url: `/benh-an-cls/${id}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function uploadImangeBaCls(id, stt, data) {
  return request({
    url: `/benh-an-cls/${id}/image-print/${stt}`,
    method: "post",
    data
  });
}

export function getImangeBaCls(id, stt) {
  return request({
    url: `/benh-an-cls/${id}/image-print/${stt}`,
    method: "get",
  });
}

export async function print(idba, stt, MaChungLoai, LoaiTaiLieu) {
  window.open(
    `${window.origin}/api/benh-an-cls/${idba}/print-ba-file/${stt}/BACLS_stt_${stt}.pdf?MaChungLoai=${MaChungLoai}&LoaiTaiLieu=${LoaiTaiLieu}`,
    "_blank"
  );
  return;
}
