import request from "@/utils/request";

export function uploadFile(data, progress = undefined) {
  return request({
    url: "/benh-an-file-phi-cau-truc",
    method: "post",
    onUploadProgress: (progressEvent) => {
      if (progress !== undefined) {
        if (progressEvent.lengthComputable) {
          progress(
            Math.round((progressEvent.loaded * 100) / progressEvent.total)
          );
        } else {
          progress(progressEvent.loaded);
        }
      }
    },
    data,
  });
}

export function getListFile(params) {
  return request({
    url: "/benh-an-file-phi-cau-truc",
    method: "get",
    params,
  });
}
export function deleteFile(idba, stt) {
  return request({
    url:  `/benh-an-file-phi-cau-truc/${idba}/chi-tiet/${stt}`,
    method: "DELETE",
  });
}

export function downloadFile(idba, stt) {
  return request({
    url: `/benh-an-file-phi-cau-truc/${idba}/download-ba-file/${stt}`,
    method: "get",
    responseType: "blob",
  });
}
