---
layout: archive
title: "Softwares"
permalink: /softwares/
author_profile: true
---
Contact information is below, including email and various web services.  This is to make it easy for people to find me when they search for things like “sebastião pais email” and get wrong pages on my site.  Here are some other places on the Internet where I reside.

{% if author.googlescholar %}
  You can also find my articles on <u><a href="{{author.googlescholar}}">my Google Scholar profile</a>.</u>
{% endif %}

{% include base_path %}

{% for post in site.publications reversed %}
  {% include archive-single.html %}
{% endfor %}
