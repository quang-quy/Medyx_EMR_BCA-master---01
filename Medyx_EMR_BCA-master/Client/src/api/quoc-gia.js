import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/dm-quoc-gia",
    method: "get",
    params,
  });
}
export function detail(id) {
  return request({
    url: `/dm-quoc-gia/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/dm-quoc-gia/${id}`,
    method: "put",
  });
}
export function detroy(id) {
  return request({
    url: `/dm-quoc-gia/${id}`,
    method: "delete",
  });
}

