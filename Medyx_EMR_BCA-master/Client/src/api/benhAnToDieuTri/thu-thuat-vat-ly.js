import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-ttvltl`,
    method: "get",
    params: {
      ...params,
    },
  });
}
export function store(data) {
  return request({
    url: `benh-an-ttvltl`,
    method: "post",
    data,
  });
}
export function storeGoi(data) {
  return request({
    url: `benh-an-ttvltl`,
    method: "post",
    data,
  });
}
export function update(idba, stt, data) {
  return request({
    url: `/benh-an-ttvltl/${idba}/chi-tiet/${stt}`,
    method: "put",
    data,
  });
}
export function destroy(idba, stt) {
  return request({
    url: `benh-an-ttvltl/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
export function ds_dichVuTTVL(params) {
  return request({
    url: `/dm-dich-vu`,
    method: "get",
    params: {
      maChungLoai: 5,
      ...params,
    },
    cache: true,
  });
}
export function ds_dichVuGoiTTVL(params) {
  return request({
    url: `/dm-dich-vu-goi`,
    method: "get",
    params: {
      loai: 4,
      sortBy: "maGoi",
      ...params,
    },
    cache: true,
  });
}
