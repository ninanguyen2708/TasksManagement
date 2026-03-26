const Navbar = {
    template: `
    <nav class="navbar">
        <div class="navbar-brand">
            <a href="index.html" class="navbar-logo">📋 Task Manager</a>
        </div>
        <ul class="navbar-links">
            <li><a href="index.html" :class="{ active: currentPage === 'home' }">🏠 Home</a></li>
            <li><a href="tasks.html" :class="{ active: currentPage === 'tasks' }">📝 Tasks</a></li>
            <li><a href="employees.html" :class="{ active: currentPage === 'employees' }">👥 Employees</a></li>
            <li><a href="categories.html" :class="{ active: currentPage === 'categories' }">📂 Categories</a></li>
            <li><a href="departments.html" :class="{ active: currentPage === 'departments' }">🏢 Departments</a></li>
        </ul>
        <div class="navbar-search">
            <input 
                type="text" 
                :placeholder="searchPlaceholder" 
                v-model="searchInput"
                @keyup.enter="$emit('search', searchInput)"
            >
            <button class="search-btn" @click="$emit('search', searchInput)">🔍</button>
        </div>
    </nav>
    `,
    props: {
        currentPage: { type: String, default: 'home' },
        searchPlaceholder: { type: String, default: 'Search...' }
    },
    emits: ['search'],
    data() {
        return {
            searchInput: ''
        };
    }
};
