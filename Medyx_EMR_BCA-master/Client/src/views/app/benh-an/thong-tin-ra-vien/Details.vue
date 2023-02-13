<template>
  <v-app>
    <v-card class="overflow-hidden" max-height="1000">
      <v-app-bar
        absolute
        color="white"
        elevate-on-scroll
        scroll-target="#scrolling-techniques-7"
      >
        <v-btn @click="onBack()" icon>
          <v-icon> mdi-arrow-left </v-icon>
        </v-btn>

        <v-toolbar-title> THÔNG TIN GIẤY RA VIỆN</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-btn icon>
          <v-icon>mdi-magnify</v-icon>
        </v-btn>

        <v-btn icon>
          <v-icon>mdi-tooltip-edit</v-icon>
        </v-btn>

        <v-btn icon>
          <v-icon>mdi-dots-vertical</v-icon>
        </v-btn>
      </v-app-bar>
      <v-sheet
        id="scrolling-techniques-7"
        class="overflow-y-auto"
        style="max-height: 100%; padding-top: 6%"
      >
        <v-container style="height: 1350px">
          <v-row>
            <v-col cols="12">
              <v-card>
                <v-card-text class="d-flex flex-wrap">
                  <div
                    class="text-lable font-weight-bold d-flex justify-center align-center"
                  >
                    <div class="text-lable"><strong>Khoa :</strong> #123</div>
                  </div>
                  <v-spacer></v-spacer>
                  <v-card-title class="d-flex justify-center mb-5">
                    <h2 class="text-uppercase">Giấy ra viện</h2>
                  </v-card-title>
                  <v-spacer></v-spacer>
                  <div class="text-lable mr-2">
                    <div>
                      <strong>MS : </strong>
                      <span>01/BV01-2</span>
                    </div>
                    <div>
                      <strong>Số lưu trữ</strong> : .......................
                    </div>
                    <div><strong>Mã y tế</strong> : .../.../.../</div>
                  </div>
                </v-card-text>
              </v-card>
            </v-col>
            <v-col cols="12">
              <v-card>
                <v-form>
                  <v-container class="py-0">
                    <v-row>
                      <!--Line 1-->
                      <v-col cols="12 " style="line-height: initial" md="6">
                        <p class="mb-2 ml-1" for="">
                          Họ và tên: {{ form.name.toUpperCase() }}
                        </p>
                      </v-col>
                      <v-spacer></v-spacer>
                      <v-col cols="12 " style="line-height: initial" md="3">
                        <p class="mb-2 ml-1" for="">Tuổi: {{ form.age }}</p>
                      </v-col>
                      <v-spacer></v-spacer>
                      <v-col cols="12" style="line-height: initial" md="3">
                        <p class="mb-2 ml-1" for="">
                          Giới tính: {{ form.gender }}
                        </p>
                      </v-col>
                      <!--Line 2-->
                      <v-col cols="12" style="line-height: initial" md="6">
                        <p class="mb-2 ml-1" for="">
                          Nghề nghiệp: {{ form.carrer }}
                        </p>
                      </v-col>
                      <v-col cols="12 " style="line-height: initial" md="6">
                        <p class="mb-2 ml-1" for="">
                          Dân tộc: {{ form.region }}
                        </p>
                      </v-col>
                      <!--Line 3-->
                      <v-col style="line-height: initial" cols="12">
                        <p class="mb-2 ml-1" for="">
                          Mã số BHXH/ Thẻ BHYT số: {{ form.code_hopital }}
                        </p>
                      </v-col>
                      <!--Line 4-->
                      <v-col style="line-height: initial" cols="12">
                        <p class="mb-2 ml-1" for="">
                          Địa chỉ: {{ form.address }}
                        </p>
                      </v-col>
                      <!--Line 5-->
                      <v-col style="line-height: initial" cols="12" md="6">
                        <template>
                          <span class="demonstration mr-4">Vào viện lúc: </span>
                          <el-date-picker
                            v-model="form.time_in"
                            type="datetime"
                            placeholder="Select date and time"
                            default-time="12:00:00"
                          >
                          </el-date-picker>
                        </template>
                      </v-col>
                      <v-col style="line-height: initial" cols="12" md="6">
                        <template>
                          <span class="demonstration mr-4">Ra viện lúc: </span>
                          <el-date-picker
                            v-model="form.time_out"
                            type="datetime"
                            placeholder="Select date and time"
                            default-time="12:00:00"
                          >
                          </el-date-picker>
                        </template>
                      </v-col>
                      <!--Line 6-->
                      <v-col style="line-height: initial" cols="12">
                        <p class="mb-2 ml-1" for="">Chuẩn đoán:</p>
                        <v-textarea
                          v-model="form.test"
                          class="purple-input"
                          outlined
                        />
                      </v-col>
                      <!--Line 7-->
                      <v-col style="line-height: initial" cols="12">
                        <p class="mb-2 ml-1" for="">Phương pháp điều trị:</p>
                        <v-textarea
                          v-model="form.how"
                          class="purple-input"
                          outlined
                        />
                      </v-col>
                      <!--Line 8-->
                      <v-col cols="12">
                        <p class="mb-2 ml-1" for="">Ghi chú:</p>
                        <v-textarea
                          v-model="form.note"
                          class="purple-input"
                          outlined
                        />
                      </v-col>
                      <!--Update-->
                      <v-col cols="12" class="text-right">
                        <v-btn rounded dark color="primary" class="mr-0">
                          Cập nhật
                        </v-btn>
                      </v-col>
                    </v-row>
                  </v-container>
                </v-form>
              </v-card>
            </v-col>
          </v-row>
        </v-container>
      </v-sheet>
    </v-card>
  </v-app>
</template>
<script>
export default {
  data: () => ({
    value: "",

    form: {
      name: "Nguyễn Văn A",
      age: 22,
      gender: "Nam",
      region: "Kinh",
      carrer: "Sinh viên",
      code_hopital: "01254789655",
      address: "Văn Quán - Hà Đông - Hà Nội",
      time_in: "",
      time_out: "",
      test: "",
      how: "",
      note: "",
    },
  }),
  created() {
    console.log(this.$route);
  },
  methods: {
    onBack() {
      this.$router.push({
        name: "Thông tin ra viện",
        params: { id: this.$route.params.id },
      });
    },
  },
};
</script>
