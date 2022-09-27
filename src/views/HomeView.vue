<template>
  <!-- Главная страница -->
  <div id="homeView" class="columns is-desktop" >
  
    <div class="filter-block  column is-one-fifth">
      <div class="search-field">
        <div class="field">
          <div class="control">
            <input class="input" type="text" placeholder="Поиск...">
          </div>
        </div>
      </div>
      <div class="filter-groups">
        <v-filter-group
          uniqName="work"
          inputType="select"
          legend="Типы работы"
          :options="[
            {name:'type', value:'tradition', text:'традицишионал'},
            {name:'type', value:'digital', text:'диджитал'},
            {name:'type', value:'animation', text:'анимация'},
          ]"/>
        <v-filter-group
          uniqName="price"
          inputType="number"
          legend="Ценовой диапазон"
          :valueAsPlaceholder="true"
          :options="[
            {name:'min', value:0, text:'От '},
            {name:'max', value:0, text:'До '},
          ]"/>
        <v-filter-group
          uniqName="style"
          inputType="select"
          legend="Типы лота"
          :options="[
            {name:'type', value:'realism', text:'реализм'},
            {name:'type', value:'styling', text:'стилизация'},
            {name:'type', value:'antro', text:'антро'},
          ]"/>
      </div>
    </div>

    <div class="content-block column">
      <div class="container">
        <div class="mb-6 columns is-multiline">
          <div class="column is-4-desktop is-6-tablet"  v-for="auc in AUCTIONS" :key="auc.id">
            <div class="card is-rounded">
              <div class="card-content  p-0">
                <div class="content" style="height: 25rem;">
                  <img :src="auc.image" alt="" style="max-height: 25rem;width: 100%;object-fit: cover;">
                </div>
              </div>
              <div class="card-footer has-background-info-light">
                <div class="card-footer-item">
                  <div class="columns is-mobile is-multiline">
                    <div class="column is-12">
                      <h4 class="title">{{auc.name}}</h4>
                    </div>
                    <div class="column is-6">
                      <p class="mb-2" style="font-size:12px;">Окончание аукциона</p><span
                        class="tag is-danger is-light" style="font-size:12px;">{{auc.timeEnd}}</span>
                    </div>
                    <div class="column is-6">
                      <p class="mb-2" style="font-size:12px;">Лучшая ставка</p><span
                        class="tag is-success is-light" style="font-size:12px;">$12,500</span>
                    </div>
                    <div 
                      class="column is-12 button is-primary is-light"
                      @click="openAuction(auc)"
                      >
                      Сделать ставку
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>

<script>
import vFilterGroup from '@/components/filter/v-filter-group.vue'
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'HomeView',
  data () {
    return {
    }
  },
  components: {
    vFilterGroup
  },
  computed: {
      ...mapGetters('auctions', [
        'AUCTIONS'
      ]),
  },
  methods: {
    ...mapActions('auctions',[
      'GET_AUCTIONS_FROM_API'
    ]),
    openAuction: function (auc) {
      this.$router.push({ name: 'auction' , query:{ id:auc.id} })
    }

  },
  mounted () {
  }
}
</script>

<style lang="scss" scoped>
.filter-block{
  padding: 1rem;
  border: 2px solid black;
  border-radius: 2rem;
  max-height: 25em;
}
.content-block {
  }
  .card {
    box-shadow: none;
    border-radius: 1rem;
    overflow: hidden;
  }
</style>
