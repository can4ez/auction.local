<template>
  <div class="wrapper">
        <v-site-header/>
        <div class="views" v-if="this.dataLoaded == true">
          <router-view/>
        </div>
        <div class="info" v-else>
          Идет загрузка данных...
        </div>
        <v-site-footer/>
  </div>
</template>

<script>
import vSiteHeader from '@/components/header/SiteHeader.vue'
import vSiteFooter from '@/components/footer/SiteFooter.vue'
import { mapGetters, mapActions } from 'vuex'

export default {
  data(){
    return { dataLoaded: false}
  },
  components: {
    vSiteHeader,
    vSiteFooter
  },
  methods: {
    ...mapActions( 'auctions' , [
      'auctionList'
    ]),
    ...mapActions( 'users' , [
      'userList'
    ]),
  },
  mounted(){
    this.userList().finally((result)=>{
      this.auctionList().finally((result)=>{
        this.dataLoaded = true;
      })
    })   ;
  },
  strict: true
}
</script>

<style lang="scss">
:root {
  --color-primary:#04ab9b;
  --color-secondary: #056454;
  --color-text-primary: #2c3e50;
  --color-text-secondary: #fff;
  --color-acccent: #54e3db;

  --color-header-bg: var(--color-primary);
  --color-header-title: var(--color-text-secondary);
  --color-header-text: var(--color-text-primary);
  --color-header-menu-bg: var(--color-acccent);
  --color-header-menu-item-bg: #00a599;
  --color-header-menu-item-text: var(--color-text-secondary);
  --color-header-menu-item-bg__active: var(--color-text-secondary);
  --color-header-menu-item-text__active: var(--color-text-primary);

  --color-footer-bg: var(--color-secondary);
  --color-footer-text: var(--color-text-secondary);
}
body{
  margin: 0;
}

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  // text-align: center;
  color: var(--color-text-primary);
  font-size: 100%;
}
.views{
  padding: 1rem;
}
#app + *{
  display: none;
}

</style>
