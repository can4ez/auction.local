<template>
    <header class='header'>

        <div class="header__row header__info">

            <router-link class="header-start" :to="{ name: 'home'}">
                <div class="header__logo">
                    <router-link
                    :to="{ name: 'home'}" >
                        <img :src="imageUrl">
                    </router-link>
                    <div class="header__title">
Интернет-аукцион<br>для художников
                    </div>
                </div>
            </router-link>

            <div class="header-end">
                <v-mini-profile/>
            </div>

        </div>

        <div class="header__row">
            <v-navbar/>
        </div>
    </header>
</template>

<script setup>
import imageUrl from '@/assets/images/logo.png'
</script>

<script>
import vNavbar from '@/components/header/NavBar.vue'
import vMiniProfile from './MiniProfile.vue'
export default {
  data () {
    return {
    }
  },
  components: { vNavbar, vMiniProfile },
  computed: {},
  methods: {
  },
  mounted () { }
}
</script>

<style lang='scss'>
    .header{
        width: 100%;

        &__row{
            display: flex;
            flex: 1 0;
            justify-content: space-between;
        }

        &-start{
            align-self: flex-start;
        }
        &-end{
            align-self: center;
        }

        &__info{
            background-color: var(--color-header-bg);
            margin-bottom: 1rem;
            padding: 0.5rem;
        }

        &__logo{
            display: flex;
        }
        &__title{
            display: flex;
            align-items: center;
            margin-left: 1em;

            font-size: 2em;
            color: var(--color-header-title);
        }
    }
</style>
