const title = process.env.VUE_APP_NAME || "Hệ thống quản lý bệnh án điện tử";

export default function getPageTitle(pageTitle) {
  if (pageTitle) {
    return `${pageTitle} - ${title}`;
  }
  return `${title}`;
}
