import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-cpm`,
    method: "get",
    params,
  });
}
export function update(idba, stt, data) {
  return request({
    url: `/benh-an-cpm/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function store(data) {
  return request({
    url: `/benh-an-cpm`,
    method: "post",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `/benh-an-cpm/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function dsChePhamMaus(params) {
  return request({
    url: `/dm-che-pham-mau`,
    method: "get",
  });
}
