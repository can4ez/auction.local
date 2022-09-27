<template>

<nav class="navbar container is-fluid p-2">
  <div class="columns is-multiline is-half">

    <router-link :to="{ name: 'home'}" class="navbar__item column"> Аукционы </router-link>
    
    <router-link :to="{ name: 'login'}" class="navbar__item column" v-if="USER.id == null"> Вход </router-link>
    <router-link :to="{ name: 'reg'}" class="navbar__item column" v-if="USER.id == null"> Регистрация </router-link>

    <router-link :to="{ name: 'profile'}" class="navbar__item column" v-if="USER.id != null"> Профиль </router-link>
  </div>
</nav>

</template>

<script>
  import { mapGetters } from 'vuex';
export default {
  data () {
    return {
    }
  },
  components: { },
  computed: {

    ...mapGetters('users', ['USER'])

  },
  methods: {
  },
  mounted () { }
}
</script>

<style lang="scss">
  nav.navbar { 
    
    justify-content: center;

    background-color: var(--color-header-menu-bg);
    padding: 0.25em 0;
.columns{
  gap: 1rem;
}
    .navbar__item{
      
      text-align: center; 
      border-radius: 2em; 

      font-weight: bold;
      text-decoration: none;

      background-color: var(--color-header-menu-item-bg);
      color: var(--color-header-menu-item-text);

      &.router-link-active{
        background-color: var(--color-header-menu-item-bg__active);
        color: var(--color-header-menu-item-text__active);
      }
    }
  }
</style>
