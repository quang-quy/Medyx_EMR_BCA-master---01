import request from "@/utils/request";

export function getSelectBox(params) {
  return request({
    url: "/benh-an-combods",
    method: "get",
    params,
    cache: true,
  });
}

export function getListBenhVien(params) {
  return request({
    url: "/benh-vien",
    method: "get",
    params,
  });
}

export function getDichVu(params) {
  return request({
    url: "/dm-dich-vu",
    method: "get",
    params,
  });
}

export function getDanhSachThuoc(params) {
  return request({
    url: `/thuoc`,
    method: "get",
    params: {
      ...params,
      isWithRelation: true,
    },
  });
}

export function getDanhMucPhauThuat(params) {
  return request({
    url: "/dm-phau-thuat",
    method: "get",
    params,
  });
}

export function getDmDichVuPhauThuat(params) {
  return request({
    url: "/DmdichvuPhanLoaiPttt",
    method: "get",
    params,
  });
}
