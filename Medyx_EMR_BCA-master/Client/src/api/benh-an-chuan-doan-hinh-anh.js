import request from "@/utils/request";

export function index(idba, params) {
  return request({
    url: "/benh-an-chuan-doan-hinh-anh",
    method: "get",
    params: {
      idba,
      ...params,
    },
  });
}
export function detail(id) {
  return request({
    url: `/benh-an-chuan-doan-hinh-anh/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/benh-an-chuan-doan-hinh-anh/${id}`,
    method: "put",
  });
}
export function destroy(id) {
  return request({
    url: `/benh-an-chuan-doan-hinh-anh/${id}`,
    method: "delete",
  });
}

