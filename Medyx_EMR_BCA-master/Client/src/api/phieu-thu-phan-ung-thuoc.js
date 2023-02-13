import request from "@/utils/request";

export function index(idba, params) {
  return request({
    url: "/benh-an-thuoc-thu-phan-ung",
    method: "get",
    params: {
      idba,
      ...params,
    },
  });
}

export function addPhieuThuPhanUngThuoc(data) {
  return request({
    url: "/benh-an-thuoc-thu-phan-ung",
    method: "post",
    data
  });
}

export function updatePhieuThuPhanUngThuoc(idba, stt, data) {
  return request({
    url: "/benh-an-thuoc-thu-phan-ung/" + idba + '/chi-tiet/' + stt,
    method: "put",
    data
  });
}

export function xoaPhieuThuPhanUngThuoc(idba, stt) {
  return request({
      url: "/benh-an-thuoc-thu-phan-ung/" + idba + '/chi-tiet/' + stt,
    method: "delete",
  });
}

export function inPhieuPhanUngThuoc(idba) {
  return request({
    url: "/benh-an-thuoc-thu-phan-ung/" + idba + '/print-ba-file/phieu-thu-phan-ung.pdf',
    method: "get",
  });
}