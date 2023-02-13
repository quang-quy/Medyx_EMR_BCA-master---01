const { defineConfig } = require("@vue/cli-service");
const path = require("path");
module.exports = defineConfig({
  transpileDependencies: ["vuetify"],
  devServer: {
    proxy: "http://localhost:5000",
  },
  runtimeCompiler: true,
  filenameHashing: false,
  outputDir: path.resolve(__dirname, "../wwwroot/client"),
  publicPath: "/client/",
});
