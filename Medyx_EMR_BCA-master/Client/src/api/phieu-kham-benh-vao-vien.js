import request from "@/utils/request";

export function getNhanVien(params) {
  return request({
    url: "/dm-nhan-vien",
    method: "get",
    params,
  });
}
export function getBuongKham(params) {
  return request({
    url: "/dm-khoa-buong",
    method: "get",
    params,
  });
}
export function getBenhTat(params) {
  return request({
    url: "/dm-benh-tat",
    method: "get",
    params,
  });
}

export function getBenhTatYHCT(params) {
  return request({
    url: "/dm-benhtat-yhct",
    method: "get",
    params,
  });
}
export function getKhoa(params) {
  return request({
    url: "/khoa",
    method: "get",
    params,
  });
}

export function getChiTietPhieuKhamVaoVien(id) {
  return request({
    url: "/benh-an-kham-vao-vien/" + id,
    method: "get",
  });
}
export function updatePhieuKhamVaoVien(id, data) {
  return request({
    url: "/benh-an-kham-vao-vien/" + id,
    method: "put",
    data,
  });
}

export function downloadFile(id) {
  return request({
    url: "/benh-an-kham-vao-vien/" + id + "/print-ba-file",
    method: "get",
    responseType: "blob",
  });
}

