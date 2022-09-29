<template>
  <div class='auctionView'>
    <!-- {{AUCTION}} -->

    <div class="error" v-if="loaded == false">
      Данные загружаются...
    </div>

    <div class="container fluid" v-else>

      <div class="columns  is-multiline">
        <div class="column is-12">
          <h4 class="title">{{INFO.name}}</h4>
        </div>
        <div class="column is-12 p-0">
          <div class="columns">
            <div class="image column is-4">
              <img :src="INFO.image" alt="" style="" class="">
            </div>
            <div class="column  is-8  p-0">
              <div class="columns is-multiline is-12 p-0">

                <article class="column is-12 message is-danger" v-if="errors.length > 0">
                  <div class="message-header" v-for="err in errors" :key="err">
                    <p>{{err}}</p>
                    <button class="delete" aria-label="delete"
                      v-on:click=" this.errors = this.errors.filter((e) => e != err); "></button>
                  </div>
                </article>

                <div class="column is-12" v-if="this.USER.id == null">
                  <article class="column is-12 message is-info" >
                    <div class="message-header">
                      <p>Войдите, чтобы сделать ставку</p>
                    </div>
                  </article>
                </div>
                <div class="column is-12" v-else>
                  <h2>Ваша ставка ....</h2>
                  <input type="number" :min="MIN_STAVKA" class="input" v-model="stavka">
                  <div class="button" @click="submitStavka(stavka)">Сделать ставку</div>
                  <div class="button" @click="submitStavka(MIN_STAVKA)">Ставка с минимальным шагом</div>
                </div>

                <div class="column is-12">
                  <h2>История ставок: </h2>
                  <div class="columns is-multiline history">
                    <p v-if="HISTORY_SORTED.length == 0">Ставок нет, вы можете быть первым...</p>
                    <div class="column is-12 p-0" v-else v-for="st in HISTORY_SORTED">
                      {{st.size}} руб. {{st.name || getUserName(st) }}
                    </div>
                  </div>
                  <h3>Начальная ставка: {{INFO.startStavka}}</h3>
                  <h3>Шаг: {{INFO.stepStavka}}</h3>
                </div>

                <div class="column is-12">
                  <h2>Описание лота:</h2>
                  <div class="columns is-multiline info">
                    <p>{{INFO.description}}</p>
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
import { mapGetters, mapActions } from 'vuex'

export default {
  data() {
    return {
      loaded: false,
      stavka: 0,
      auction: null,
      errors: []
    }
  },
  components: {
  },
  computed: {

    INFO: function () {
      return this.auction.auctionInfo;
    },

    HISTORY: function () {
      return this.auction.listStavka;
    },
    HISTORY_SORTED: function () {
      return this.HISTORY.sort((a, b) => { return a.size < b.size });
    },
    MAX_STAVKA: function () {
      return this.HISTORY.reduce((a, b) => {
        return { size: Math.max(a.size, b.size) };
      }, { size: this.INFO.startStavka }).size;
    },

    MIN_STAVKA: function () {
      return this.MAX_STAVKA + Number(this.INFO.stepStavka);
    },

    ...mapGetters('users', ['USER']),
  },
  methods: {
    ...mapActions('users', ['getUserByID']),
    ...mapActions('auctions', ['getAuctionInfo', 'auctionStavka', 'auctionList']),

    submitStavka: function (stavka) {
      this.stavka = stavka;
      this.errors = [];
      if (stavka < this.MIN_STAVKA) {
        this.errors = ['Минимальная ставка: ' + this.MIN_STAVKA]
        return;
      }

      this.auctionStavka({
        auctionId: this.$route.query.id,
        idUser: this.USER.id,
        time: 0,
        size: this.stavka
      }).then((result) => {
        this.auctionList().then((response) => {
          this.loadAuctionData();
        });
      });
    },

    getUserName: function (st) {
      this.getUserByID(st.idUser).then((e) => {
        st.name = e.name;
      });
    },

    loadAuctionData() {
      this.getAuctionInfo(this.$route.query.id).then((result) => {
        this.auction = result;
        this.stavka = this.MIN_STAVKA;
        this.loaded = true;
      })
    }
  },
  mounted() {
    if (this.$route.query.id == undefined) {
      this.$route.push({ name: 'home' })
      return;
    }

    this.loadAuctionData();
  }
}
</script>

<style lang='scss'>
.history {
  max-height: 10rem;
  overflow-y: auto;
  overflow-x: hidden;
  padding: 1rem;
  background-color: var(--color-acccent);
}
</style>
