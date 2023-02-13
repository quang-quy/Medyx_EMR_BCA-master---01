import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/benh-an-phieu-cham-soc",
    method: "get",
    params,
  });
}

export function chiTietPhieuChamSoc(idba, stt) {
  return request({
    url: `/benh-an-phieu-cham-soc/${idba}/chi-tiet/${stt}`,
    method: "get",
  });
}

export function addPhieuChamSoc(data) {
  return request({
    url: "/benh-an-phieu-cham-soc",
    method: "post",
    data
  });
}

export function updatePhieuChamSoc(idba, stt, data) {
  return request({
    url: `/benh-an-phieu-cham-soc/${idba}/chi-tiet/${stt}`,
    method: "put",
    data
  });
}

export function xoaPhieuChamSoc(idba, stt) {
  return request({
    url: `/benh-an-phieu-cham-soc/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function saoChepPhieuChamSoc(data) {
  return request({
    url: `/benh-an-phieu-cham-soc/sao-chep`,
    method: "post",
    data
  });
}

export async function print(idba, params) {
  window.open(
    `${window.origin}/api/benh-an-phieu-cham-soc/${idba}/print-ba-file/phieu-cham-soc.pdf?${params}`,
    "_blank"
  );
  return;
}
export async function printSoDo(idba, params) {
  window.open(
    `${window.origin}/api/benh-an-phieu-cham-soc/${idba}/print-ba-file/so-do/bieu-do-chuc-nang.pdf?${params}`,
    "_blank"
  );
  return;
}
