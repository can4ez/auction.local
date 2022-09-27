const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig({
  transpileDependencies: true,
  publicPath: './',
  css: {
    loaderOptions: {
      // по умолчанию опция `sass` будет применяться к обоим синтаксисам
      // потому что синтаксис `scss` по сути также обрабатывается sass-loader
      // но при настройке опции `prependData` синтаксис `scss` требует точку с запятой
      // в конце оператора, в то время как для `sass` точки с запятой не требуется
      // в этом случае синтаксис `scss` можно настроить отдельно с помощью опции `scss`
      scss: {
        // additionalData: '@import "~@/scss/app.scss";'
      }
    }
  }
})
