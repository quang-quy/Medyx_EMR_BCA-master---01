import request from "@/utils/request";

export function index(idba, params) {
  return request({
    url: "/benh-an-phau-thuat",
    method: "get",
    params: {
      idba,
      ...params,
    },
  });
}
export function detail(id) {
  return request({
    url: `/benh-an-phau-thuat/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/benh-an-phau-thuat/${id}`,
    method: "put",
  });
}
export function detroy(id) {
  return request({
    url: `/benh-an-phau-thuat/${id}`,
    method: "delete",
  });
}
