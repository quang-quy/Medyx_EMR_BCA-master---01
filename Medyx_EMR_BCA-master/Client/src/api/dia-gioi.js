import request from "@/utils/request";

export function getQuanHuyen(params) {
    return request({
      url: "/quan-huyen",
      method: "get",
      params
    });
  }
  export function getTinhThanh() {
    return request({
      url: "/tinh",
      method: "get",
    });
  }
  export function getXaPhuong(params) {
    return request({
      url: "/phuong-xa",
      method: "get",
      params
    });
  }