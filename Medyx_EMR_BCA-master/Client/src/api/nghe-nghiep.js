import request from "@/utils/request";

export function getNgheNghiep() {
    return request({
      url: "/nghe-nghiep",
      method: "get",
    });
  }