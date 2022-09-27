
import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import { store } from './store';

import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faUserSecret, faSearch } from '@fortawesome/free-solid-svg-icons'

import './assets/sass/main.scss'

library.add({ faUserSecret, faSearch })

createApp(App)
  .use(store)
  .use(router)
  .component('font-awesome-icon', FontAwesomeIcon)
  .mount('#app')
  
