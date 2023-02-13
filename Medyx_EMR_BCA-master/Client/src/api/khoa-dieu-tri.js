import request from "@/utils/request";

export function index(idba, params) {
  return request({
    url: `/benh-an-khoa-dieu-tri`,
    method: "get",
    params: {
      idba,
      forSelect: true,
      huy: false,
      ...params,
    },
  });
}
export function indexAdmin(idba, params) {
  return request({
    url: `/benh-an-khoa-dieu-tri`,
    method: "get",
    params: {
      idba,
      ...params,
    },
  });
}
export function store(idba, data) {
  data.giuong = data.maGiuong;
  data.buong = data.maBuong;
  return request({
    url: `/benh-an-khoa-dieu-tri`,
    method: "post",
    data: {
      idba,
      ...data,
    },
  });
}
export function update(idba, stt, data) {
  data.giuong = data.maGiuong;
  data.buong = data.maBuong;
  return request({
    url: `/benh-an-khoa-dieu-tri/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `/benh-an-khoa-dieu-tri/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function dsBenhs(params) {
  return request({
    url: "/dm-benh-tat",
    method: "get",
    params,
  });
}
