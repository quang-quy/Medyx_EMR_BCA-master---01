<template>
  <center>
    <h1>Bạn không có quyền truy cập!</h1>
    <p>
      <a href="/">Trở về trang chủ?</a>
    </p>
  </center>
</template>

<script>
export default {
  name: "NotFound",
};
</script>

<style scoped>
center {
  margin: 15vw;
}

h1 {
  color: var(--border);
  font-size: 2em;
}
</style>