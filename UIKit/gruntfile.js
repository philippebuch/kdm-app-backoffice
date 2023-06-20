module.exports = function(grunt) {

	// Import package
	grunt.loadNpmTasks('grunt-text-replace');
	grunt.loadNpmTasks('grunt-contrib-less');
	// grunt.loadNpmTasks('grunt-autoprefixer');
	grunt.loadNpmTasks('grunt-contrib-watch');
	grunt.loadNpmTasks('grunt-contrib-concat');
	grunt.loadNpmTasks('grunt-contrib-uglify');
	grunt.loadNpmTasks('grunt-contrib-copy');
	grunt.loadNpmTasks('grunt-contrib-clean');
	grunt.loadNpmTasks('grunt-contrib-pug');


	grunt.initConfig({
		
		pkg: grunt.file.readJSON('package.json'),
		
		//
		// Replace prefix and ProjectName
		// --------------------------------------------------
		replace: {
			prx: {
			  src: [
				'src/js/*' ,
				'src/views/*' ,
				'src/less/*' ,
				'data/locals.json' ,
				'.gitignore',
				'README.md'
			  ],
			  overwrite: true,
			  replacements: [
			  {
				  from: 'rco',
				  to: '<%= pkg.prefix %>'
			  },
			  {
				  from: 'RCO',
				  to: '<%= pkg.name %>'
			  }]
			},
			deliverypath:{
				src:['../source/rvo-app/src/assets/*'],
				overwrite: true,
				replacements: [
					{
						from: '../fonts/',
						to: '/fonts/'
					},
					{
						from: '../icons/',
						to: '/icons/'
					},
					{
						from: '../img/',
						to: '/img/'
					}
				]
			}
		},

		//
		// Define css and Js banners
		// --------------------------------------------------
		bannerCss: '/*!\n' +
			' * <%= pkg.name %> v<%= pkg.version %> Core css file \n' +
			' * Last modification: <%= grunt.template.today("yyyy/mm/dd") %>\n' +
			' * Author: <%= pkg.author %>\n' +
			' */\n',

		bannerJs: '/*!\n' +
			' * <%= pkg.name %> v<%= pkg.version %> Core js file \n' +
			' * Last modification: <%= grunt.template.today("yyyy/mm/dd") %>\n' +
			' * Author: <%= pkg.author %>\n' +
			' */\n',


		//
		// Less compile task
		// --------------------------------------------------

		less: {
			client: {
				options: {
					paths: ['src/less/'],
					banner: '<%= bannerCss %>'
				},
				files: {
					"build/css/<%= pkg.prefix %>-core.css": "src/less/_core.less"
				},
			},

			clientMin: {
				options: {
					paths: ['src/less/'],
					compress: true,
					banner: '<%= bannerCss %>'
				},
				files: {
					"build/css/<%= pkg.prefix %>-core.min.css": "src/less/_core.less"
				},
			},

			uikit: {
				options: {
					paths: ['src/less/'],
					// banner: 'Last modification: <%= grunt.template.today("yyyy/mm/dd") %>'
				},
				files: {
					"build/uikit/assets/uikit.css": "src/less/__uikit/_uikit.less"
				},
			}

		},

		//
		// Autoprefixer (depreciated, use grunt-postcss if needed )
		// --------------------------------------------------
		
		// autoprefixer: {
		//   autoPrefixCore: {
		//     expand: true,
		//     flatten: true,
		//     browsers: ['last 2 versions'],
		//     src: "../<%= pkg.name %>.Src/Assets/css/unmin/<%= pkg.prefix %>-core.css",
		//     dest: "../<%= pkg.name %>.Src/Assets/css/unmin/"
		//   },
		//   autoPrefixCoreMin: {
		//     expand: true,
		//     flatten: true,
		//     browsers: ['last 2 versions'],
		//     src: "../<%= pkg.name %>.Dist/<%= pkg.name %>.Assets/css/<%= pkg.prefix %>-core.min.css",
		//     dest: "../<%= pkg.name %>.Dist/<%= pkg.name %>.Assets/css/"
		//   }, 
		// }, 


        // grunt-contrib-concat
        // -------------------
        concat: {
            options: {
                separator: ''
            },
            js: {
                src: ['src/js/*'], 
                dest: 'build/js/<%= pkg.prefix %>-scripts.js'
            },
            vendor: {
                src: ['src/js/vendor/jquery-3.6.0.min.js'],
                dest: 'build/js/vendor.js'
            }
        },
        
        // grunt-contrib-uglify
        // Minify JS
        // -------------------

		uglify: {
			options: {
				banner: '<%= bannerJs %>',
				preserveComments: 'some'
			},
			client: {
				src: 'src/js/scripts.js',
				dest: 'build/js/<%= pkg.prefix %>-scripts.min.js'
				// dest: '../<%= pkg.name %>.Dist/<%= pkg.name %>.Toolbox/bin/js/<%= pkg.prefix %>-scripts.min.js'
			}
		},

		//
		// grunt-contrib-pug
		// --------------------------------------------------
		pug: {
			build: {
				options: {
					pretty: true,
					data: function(dist, src) {
						var jsonSrc = require('./data/locals.json');
						var jsonIcon = require('./src/icons/selection.json');
						return {
							strings: jsonSrc.global,
							jsondata: jsonSrc,
							pages: jsonSrc.pages,
							jsonicons: jsonIcon.icons,
							inABuild: true
						};
					}
				},
				files: [{
					cwd: 'src/views',
					src: ['./*.pug', './uikit/*.pug'],
					dest: "build",
					expand: true,
					ext: '.html'
				}]
			}
		},

		//
		// Copy files
		// --------------------------------------------------
		copy: {
			icons: {
				expand: true,
				cwd: 'src/icons/fonts/',
				src: '**',
				dest: 'build/icons/',
			},
			fonts: {
				expand: true,
				cwd: 'src/fonts/',
				src: '**',
				dest: 'build/fonts/',
			},
			img: {
				expand: true,
				cwd: 'src/img/',
				src: '**',
				dest: 'build/img/',
			},
			uikitJs: {
                files: [
                    {expand: true, cwd: 'src/js/uikit', src: 'uikit.js', dest: 'build/uikit/assets'}
                ]
            },
			build: {
                files: [
                    {expand: true, cwd: 'src/fonts', src: '**', dest: 'build/fonts'},
					{expand: true, cwd: 'src/icons/fonts/', src: '**', dest: 'build/icons/'},
                    {expand: true, cwd: 'src/img', src: '**', dest: 'build/img'},
                    {expand: true, cwd: 'src/js/', src: '*.js', dest: 'build/js'},
                    {expand: true, cwd: 'src/js/uikit/vendor', src: '*.js', dest: 'build/uikit/assets'},
					{expand: true, cwd: 'src/js/uikit', src: 'uikit.js', dest: 'build/uikit/assets'}
                ]
            },
			appAssets: {
                files: [
                    {expand: true, cwd: 'build/fonts/', src: '**', dest: '../source/rvo-app/public/fonts/'},
					{expand: true, cwd: 'build/icons/', src: '**', dest: '../source/rvo-app/public/icons/'},
                    {expand: true, cwd: 'build/css/', src: 'rvo-core.css', dest: '../source/rvo-app/src/assets/'},
                    {expand: true, cwd: 'build/img/', src: '**', dest: '../source/rvo-app/public/img/'}
                ]
            }

		},

		//
		// grunt-contrib-clean
        // -------------------
        clean: {
            build: ['build/*'],
            img: ['build/img/**/*'],
            icons: ['build/icons/*'],
			appAssets: ['../source/rvo-app/src/assets/rvo-core.css', '../source/rvo-app/public/icons/*', '../source/rvo-app/public/fonts/*', '../source/rvo-app/public/img/**/*']
		},

		//
		// Watch files when something change
		// --------------------------------------------------
		watch: {
			less: {
				files: ['src/less/**' , '!src/less/__uikit/**'],
				tasks: ['less:client', 'less:clientMin']
			},
			js:{
				files: 'src/js/**',
				tasks:'uglify'
			},
			uikitLess: {
				files: ['src/less/__uikit/**'],
				tasks: ['less:uikit']
			},
			uikitJs: {
                files: 'src/js/uikit/uikit.js',
                tasks: ['copy:uikitJs']
            },
			icons:{
				files: 'src/icons/fonts/**',
				tasks:'copy:icons'
			},
			img:{
				files: 'src/img/**',
				tasks:'copy:img'
			}
		},

	});

	//
	// Tasks
	// --------------------------------------------------
	grunt.registerTask('init', ['replace']);
	grunt.registerTask('default', ['watch']);
	grunt.registerTask('build', ['clean:build', 'concat', 'pug:build', 'less', 'uglify', 'copy:build']);
	grunt.registerTask('delivery', ['clean:appAssets', 'copy:appAssets', 'replace:deliverypath']);


}