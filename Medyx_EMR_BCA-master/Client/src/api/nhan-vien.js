import request from "@/utils/request";

export function index(params) {
  return request({
    url: "/dm-nhan-vien",
    method: "get",
    params,
  });
}
export function detail(id) {
  return request({
    url: `/dm-nhan-vien/${id}`,
    method: "get",
  });
}
export function update(id) {
  return request({
    url: `/dm-nhan-vien/${id}`,
    method: "put",
  });
}
export function detroy(id) {
  return request({
    url: `/dm-nhan-vien/${id}`,
    method: "delete",
  });
}

