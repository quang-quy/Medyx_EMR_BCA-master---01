import request from "@/utils/request";

export function uploadFile(data) {
  return request({
    url: "/benh-an-file-phi-cau-truc",
    method: "post",
    data,
  });
}

export function getListFile(params) {
  return request({
    url: "/benh-an-file-phi-cau-truc",
    method: "get",
    params: {
      ...params,
    },
  });
}
export function deleteFile(idba, stt) {
  return request({
    url: `/benh-an-file-phi-cau-truc/${idba}/chi-tiet/${stt}`,
    method: "delete",
    data: {
      huy: true,
    },
  });
}

