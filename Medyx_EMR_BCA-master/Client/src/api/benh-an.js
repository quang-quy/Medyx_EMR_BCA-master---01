import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/benh-an",
    method: "get",
    params,
  });
}
export function createBa(data) {
  return request({
    url: "/benh-an/them-moi-thong-tin-benh-an",
    method: "post",
    data,
  });
}
export function updateThongTinChung(id,data) {
  return request({
    url: `/benh-an/${id}/cap-nhap-thong-tin-benh-an/`,
    method: "post",
    data
  });
}
export function updateDongThongTinChung(id,data) {
  return request({
    url: `/benh-an/${id}/dong-thong-tin-benh-an/`,
    method: "post",
    data
  });
}
export function update(id,data) {
  return request({
    url: `/benh-an/${id}/cap-nhap-to-benh-an`,
    method: "post",
    data
  });
}
export function destroy(id) {
  return request({
    url: `/benh-an/${id}`,
    method: "delete",
  });
}

export function getLoaiBenhAn() {
  return request({
    url: "/loai-benh-an",
    method: "get",
  });
}
export function getKhoa() {
  return request({
    url: "/khoa",
    method: "get",
    cache: true,
  });
}
export function GetByAccount() {
    return request({
        url: "/khoa/GetByAccount",
        method: "get",
        //cache: true,
    });
}
export function getDetailBenhAn(id) {
  return request({
    url: "/benh-an/" + id,
    method: "get",
  });
}

export function chiTietToBenhAn(id) {
  return request({
    url: "/benh-an/" + id + "/detail",
    method: "get",
  });
}

export function getTienSuBenh(id, params) {
  return request({
    url: "/benh-an-tien-su-benh/" + id,
    method: "get",
    params
  });
}
export function getKhamYhhd(id) {
  return request({
    url: "/benh-an-kham-yhhd/" + id,
    method: "get",
  });
}

export function getKhamYhct(id) {
  return request({
    url: "/benh-an-kham-yhct/" + id,
    method: "get",
  });
}

export function getTongKetBenhAn(id) {
  return request({
    url: "/benh-an-tong-ket-benh-an/" + id,
    method: "get",
  });
}

export function getKhoaDieuTri(params) {
  return request({
    url: "/benh-an-khoa-dieu-tri/",
    method: "get",
    params
  });
}

export function getLoai(id) {
  return request({
    url: "/benh-an/" + id + "/loai-benh-an",
    method: "get",
  });
}

export function printBa(idba) {
  window.open(
    `${window.origin}/api/benh-an/${idba}/print-ba-file/${idba}.pdf`,
    "_blank"
  );
  return;
}

