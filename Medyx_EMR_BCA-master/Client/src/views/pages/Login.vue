<template>
  <v-app @keyup.enter.native="login">
    <v-main>
      <v-container fluid class="section-container">
        <div class="signin">
          <div class="left"></div>
          <div class="right">
            <h2>Hệ thống quản lý bệnh án</h2>

            <v-form ref="form" v-model="isValid">
              <v-text-field
                v-model="form.username"
                label="Email"
                :rules="[(v) => !!v || 'Hãy nhập email']"
                outlined
                dark
                filled
                dense
              ></v-text-field>

              <v-text-field
                v-model="form.password"
                label="Mật khẩu"
                :append-icon="showPass ? 'mdi-eye' : 'mdi-eye-off'"
                @click:append="showPass = !showPass"
                :rules="[(v) => !!v || 'Hãy nhập mật khẩu']"
                outlined
                dense
                dark
                filled
                :type="showPass ? 'text' : 'password'"
              ></v-text-field>

              <div class="text-center">
                <v-btn
                  :loading="loading"
                  class="signin-btn"
                  rounded
                  color="white"
                  dark
                  @click="login"
                >
                  Đăng nhập
                </v-btn>
              </div>
            </v-form>
          </div>
        </div>
      </v-container>
    </v-main>
  </v-app>
</template>
<script>
export default {
  data: () => ({
    isValid: true,
    form: {
      username: "",
      password: null,
    },
    showPass: false,
    loading: false,
  }),

  methods: {
    async login() {
      await this.$refs.form.validate();
      if (!this.isValid) return;
      this.loading = true;
      try {
        await this.$store.dispatch("auth/login", this.form);
        this.$router.push("/");
      } catch (error) {
        this.loading = false;
      }
    },
  },
};
</script>

<style lang="scss">
.section-container {
  height: 100vh;
  padding: 0;
  .signin {
    width: 100%;
    height: 100%;
    display: flex;
    .left {
      display: flex;
      background-image: url("@/assets/app/hospital.jpg");
      width: calc(100vw - 400px);
      background-size: contain;
    }
    .right {
      padding: 30px;
      width: 400px;
      box-sizing: border-box;
      background: #1a75bd;
      color: #fff;
      h2 {
        text-align: center;
        margin: 30px 0;
      }
      .signin-btn {
        width: 100%;
        color: #1a75bd;
      }
    }
  }
}
</style>
