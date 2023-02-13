import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-ttvlt-thuc-hien`,
    method: "get",
    params,
  });
}
export function show(idba , stt) {
  return request({
    url: `/benh-an-ttvlt-thuc-hien/${idba}/chi-tiet/${stt}`,
    method: "get",
  });
}
export function store(data) {
  return request({
    url: `/benh-an-ttvlt-thuc-hien`,
    method: "post",
    data
  });
}
export function update(idba , stt , data) {
  return request({
    url: `/benh-an-ttvlt-thuc-hien/${idba}/chi-tiet/${stt}`,
    method: "put",
    data
  });
}
export function destroy(idba , stt) {
  return request({
    url: `/benh-an-ttvlt-thuc-hien/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}

// list phuong phap
export function getListPPVLTL(params) {
  return request({
    url: `/benh-an-ttvltl`,
    method: "get",
    params,
  });
}

