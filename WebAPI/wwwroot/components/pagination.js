// source: https://www.digitalocean.com/community/tutorials/vuejs-vue-pagination-component
const Pagination = {
    template: `
    <ul class="pagination">
        <li class="pagination-item">
            <button type="button" @click="firstPage" :disabled="isFirstPage">First</button>
        </li>
        <li class="pagination-item">
            <button type="button" @click="previousPage" :disabled="isFirstPage">Previous</button>
        </li>
        <!-- visible button start -->

        <li v-for="pg in pages" :key="pg.name" class="pagination-item">
            <button type="button" @click="goToPage(pg.name)" :disabled="pg.isDisabled" :class="{ active: isPageActive(pg.name) }">{{ pg.name }}</button>
        </li>
        <!-- visible button end -->
        <li class="pagination-item">
            <button type="button" @click="nextPage" :disabled="isLastPage">Next</button>
        </li>

        <li class="pagination-item">
            <button type="button" @click="lastPage" :disabled="isLastPage">Last</button>
        </li>
    </ul>
    `,
    props: {
        maxVisibleButtons: {
            type: Number,
            required: false,
            default: 3
        },    
        totalPages: {
            type: Number,
            required: true
        },
        perPage: {
            type: Number,
            required: true
        },
        currentPage: {
            type: Number,
            required: true
        }
    },
    computed: {
        startPage() {
            // When on the first page
            if (this.currentPage === 1) {
                return 1;
            }

            // When on the last page
            if (this.currentPage === this.totalPages) {
                return Math.max(this.totalPages - this.maxVisibleButtons + 1, 1);
                // return this.totalPages - this.maxVisibleButtons;
            }

            // When inbetween
            return this.currentPage - 1;
        },
        pages() {
            const range = [];
            let st = this.startPage, n = Math.min(st + this.maxVisibleButtons - 1, this.totalPages);
            for (let i = st; i <= n; i++) {
                range.push({
                    name: i,
                    isDisabled: i === this.currentPage
                });
            }

            return range;
        },
        isFirstPage() {
            return this.currentPage === 1;
        },
        isLastPage() {
            return this.currentPage === this.totalPages;
        }
    },
    methods: {
        firstPage() {
            this.$emit('pagechanged', 1);
        },
        previousPage() {
            if (!this.isFirstPage) {
                this.$emit('pagechanged', this.currentPage - 1);
            }
        },
        goToPage(pageNum) {
            this.$emit('pagechanged', pageNum);
        },
        nextPage() {
            if (!this.isLastPage) {
                this.$emit('pagechanged', this.currentPage + 1);
            }
        },
        lastPage() {
            this.$emit('pagechanged', this.totalPages);
        },
        isPageActive(page) {
            return this.currentPage === page;
        }
    }
}