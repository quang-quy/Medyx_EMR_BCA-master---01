import request from "@/utils/request";

export function getDoiTuong() {
    return request({
      url: "/doi-tuong",
      method: "get",
    });
  }