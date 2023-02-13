import request from "@/utils/request";

export function index(params) {
  return request({
    url: `/benh-an-loai-tai-lieu`,
    method: "get",
    params: {
      ...params,
    },
  });
}
export function indexDV(params) {
  return request({
    url: `/benh-an-file-phi-cau-truc`,
    method: "get",
    params: {
      ...params,
    },
  });
}
export function dmDv(params) {
  return request({
    url: `/dm-dich-vu`,
    method: "get",
    params: {
      ...params,
    },
  });
}
export function upLoadFile(data) {
  return request({
    url: `/benh-an-file-phi-cau-truc`,
    method: "post",
    data
  });
}
export function dmDvLoaiTl(params) {
  return request({
    url: `/benh-an-loai-tai-lieu/dich-vu`,
    method: "get",
    params: {
      ...params,
    },
  });
}
export function detroyFile(idba, stt) {
  return request({
    url: `/benh-an-file-phi-cau-truc/${idba}/chi-tiet/${stt}`,
    method: "delete",
  });
}
