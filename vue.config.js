const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig({
  devServer: {
    // 'auto' | 'all' [string] here
    allowedHosts: 'all',
  },
  transpileDependencies: true,
  publicPath: './'
})
